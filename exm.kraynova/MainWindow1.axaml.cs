using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace exm.kraynova;

public partial class regis : Window
{
    private MySqlConnection _connection;
    private string connectionString = "server=localhost;port=10.10.11.4;database=exm.kr;user id=root;password=123456)";
    public regis()
    {
        InitializeComponent();
    }

    private void Add_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            string insert = "INSERT INTO stuff (name, last_name, phone, year, mw) VALUES (' " +text1.Text+"','"+text2.Text+"', '"+text3.Text+"', '"+text4.Text+"', '"+text5.Text+"')";
            MySqlCommand command = new MySqlCommand(insert, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            text1.Text = "Succesfully data";
        }
        catch (Exception exception)
        {
            text1.Text = "Incorrect data";
        }
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow _mainWindow = new MainWindow();
        _mainWindow.Show();
        this.Hide();
    }
}