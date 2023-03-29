using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Windows.Controls;
using System.Windows;
using BLL.BLL;
using DTO.Model;
using System.Diagnostics;

namespace WPFGUI;

public partial class MainWindow : Window
{
    private AircraftBLL aircraftBLL = new AircraftBLL();
    public MainWindow()
    {
        this.DataContext = aircraftBLL;

        InitializeComponent();

        AirlinesList.ItemsSource = aircraftBLL.GetAirlines();
        AirlinesList.SelectionChanged += AirlinesList_SelectionChanged;
        

        AircraftList.ItemsSource = aircraftBLL.GetAircrafts();
        AircraftList.SelectionChanged += AircraftList_SelectionChanged;

        AddBtn.Click += AddButton_Click;
        EditBtn.Click += EditButton_Click;
        RemoveBtn.Click += RemoveButton_Click;
    }

    private void AirlinesList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            AirlineDetail airlineDetail = aircraftBLL.GetAirline(((Airline)AirlinesList.SelectedItem).AirlineID);
            AircraftList.ItemsSource = airlineDetail.Aircrafts;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void RemoveButton_Click(object? sender, RoutedEventArgs e)
    {
        Aircraft aircraft = (Aircraft)AircraftList.SelectedItem;
        aircraftBLL.RemoveAircraft(aircraft);
        AircraftList.ItemsSource = aircraftBLL.GetAircrafts();
    }

    private void EditButton_Click(object? sender, RoutedEventArgs e)
    {
        
        string name = txtName.Text;
        double wingSpan = double.Parse(txtWingspan.Text);
        double maxCrz = double.Parse(txtMaxCruise.Text);
        int id = ((Aircraft)(AircraftList.SelectedItem)).AircraftID;
        aircraftBLL.EditAircraft(new Aircraft(id, name, wingSpan, maxCrz));
        AircraftList.ItemsSource = aircraftBLL.GetAircrafts();
        
    }

    private void AddButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            string name = txtName.Text;
            double wingSpan = double.Parse(txtWingspan.Text);
            double maxCrz = double.Parse(txtMaxCruise.Text);
            aircraftBLL.AddAircraft(new Aircraft(name, wingSpan, maxCrz), ((Airline)AirlinesList.SelectedItem).AirlineID);
            AirlineDetail airlineDetail = aircraftBLL.GetAirline(((Airline)AirlinesList.SelectedItem).AirlineID);
            AircraftList.ItemsSource = airlineDetail.Aircrafts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void AircraftList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        
        try
        {
            Aircraft aircraft = (Aircraft)AircraftList.SelectedItem;
            txtName.Text = aircraft.Name;
            txtWingspan.Text = aircraft.WingSpan + "";
            txtMaxCruise.Text = aircraft.MaxCrz + "";
        }
        catch (Exception err)
        {
            Console.WriteLine(err);
        }
        

    }
}