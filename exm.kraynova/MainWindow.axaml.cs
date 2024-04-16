using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace exm.kraynova;

public partial class MainWindow : Window {
    private MySqlConnection _mySqlConnection;
    private string connectionString = "server=localhost;port=10.10.11.4;database=exm.kr;user id=root;password=123456)";
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Enter_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            string sql1 = "SELECT phone, password, role_id FROM users WHERE phone = '" + phone.Text + "' AND password = '" +
                          password.Text + "' AND role_id = '1'";
            _mySqlConnection = new MySqlConnection(connectionString);
            _mySqlConnection.Open();
            string sql2 = "SELECT phone, password, role_id FROM users WHERE phone = '" + phone.Text + "' AND password = '" +
                          password.Text + "' AND role_id = '2'";
            MySqlCommand sqlCommand = new MySqlCommand(sql2, _mySqlConnection);
            MySqlCommand mySqlCommand = new MySqlCommand(sql1, _mySqlConnection);
            if (mySqlCommand.ExecuteScalar() != null)
            {
            
                bottom _bottom = new bottom();
                this.Hide();
                _bottom.Show();
            }
            if (sqlCommand.ExecuteScalar() != null)
            {
                bottom _bottom = new bottom();
                this.Hide();
                _bottom.Add.IsVisible = false;
                _bottom.Update.IsVisible = false;
                _bottom.Show();
                login.Text = "Sucessfully";
            }
        }
        catch (Exception exception)
        {
            phone.Text = "Incorrect phone or password)";
        }
        
    }

    private void Register_OnClick(object? sender, RoutedEventArgs e)
    {
        regis _regis = new regis();
        this.Hide();
        _regis.Show();
    }
}
