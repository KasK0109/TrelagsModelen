using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BLL.BLL;
using DTO.Model;

namespace GUI;

public partial class MainWindow : Window
{
    private SwordBLL swordBLL = new SwordBLL();
    public MainWindow()
    {
        InitializeComponent();

        ListBoxOwners.Items = swordBLL.GetSwordOwners();
        ListBoxOwners.SelectionChanged += ListBoxOwnersOnSelectionChanged;
        
        ListBoxSwords.Items = swordBLL.GetSwords();
        ListBoxSwords.SelectionChanged += ListBoxSwordsOnSelectionChanged;

        AddBtn.Click += AddBtnOnClick;
        EditBtn.Click += EditBtnOnClick;
        RemoveBtn.Click += RemoveBtnOnClick;
    }

    private void ListBoxOwnersOnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        SwordOwnerDetail so = swordBLL.GetSwordOwner(((SwordOwner)ListBoxOwners.SelectedItem).SwordOwnerID);
        ListBoxSwords.Items = so.Swords;
    }

    private void RemoveBtnOnClick(object? sender, RoutedEventArgs e)
    {
        Sword sword = (Sword)ListBoxSwords.SelectedItem;
        swordBLL.RemoveSword(sword);
        ListBoxSwords.Items = swordBLL.GetSwords();
    }

    private void EditBtnOnClick(object? sender, RoutedEventArgs e)
    {
        string name = NameTb.Text;
        double blade = double.Parse(BladeTb.Text);
        double handle = double.Parse(HandleTb.Text);
        int id = ((Sword)(ListBoxSwords.SelectedItem)).SwordID;
        swordBLL.EditSword(new Sword(id,name, blade, handle));
        ListBoxSwords.Items = swordBLL.GetSwords();
    }

    private void AddBtnOnClick(object? sender, RoutedEventArgs e)
    {
        string name = NameTb.Text;
        double blade = double.Parse(BladeTb.Text);
        double handle = double.Parse(HandleTb.Text);
        swordBLL.AddSword(new Sword(name, blade, handle));
        ListBoxSwords.Items = swordBLL.GetSwords();
    }

    private void ListBoxSwordsOnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            Sword sword = (Sword)ListBoxSwords.SelectedItem;
            NameTb.Text = sword.Name;
            BladeTb.Text = sword.BladeLength + "";
            HandleTb.Text = sword.HandleLength + "";
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }
        
    }
}