﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber = 0;
        double newNumber = 0;
        SelectedOperator selectedOperator;


        public MainWindow()
        {
            InitializeComponent();           
        }


        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            if (lastNumber !=0)
            {
                newNumber = lastNumber * (Convert.ToDouble(lblResult.Content.ToString()) / 100);
            }
            else
            {
                lblResult.Content = (Convert.ToDouble(lblResult.Content.ToString()) / 100).ToString();
            }
        }



        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = (Convert.ToDouble(lblResult.Content.ToString()) * -1).ToString();
        }


        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {            
            if (lastNumber != 0 )
            {
                if (newNumber == 0)
                {
                    newNumber = Convert.ToDouble(lblResult.Content.ToString());
                }                

                switch (selectedOperator)
                {
                    case SelectedOperator.Multiplication:
                        lblResult.Content = SimpleMath.Multiplicate(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        lblResult.Content = SimpleMath.Sustract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Addition:
                        lblResult.Content = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        lblResult.Content = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                lastNumber = Convert.ToDouble(lblResult.Content.ToString());
                newNumber = 0;
            }
        }


        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!lblResult.Content.ToString().Contains("."))
            {
                lblResult.Content += ".";
            }
        }


        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = 0;
            newNumber = 0;
            lblResult.Content = "0";

        }


        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {

            if (lastNumber == 0)
            {
                lastNumber = Convert.ToDouble(lblResult.Content.ToString());               
            }

            lblResult.Content = "0";

            Button pressedOperationButton = (Button)sender;            

            switch (pressedOperationButton.Content)
            {
                case "+":
                    selectedOperator = SelectedOperator.Addition;
                    break;
                case "-":
                    selectedOperator = SelectedOperator.Substraction;
                    break;
                case "*":
                    selectedOperator = SelectedOperator.Multiplication;
                    break;
                case "/":
                    selectedOperator = SelectedOperator.Division;
                    break;
            }
        }


        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button pressedNumberButton = (Button)sender;

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = pressedNumberButton.Content.ToString();
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}" + pressedNumberButton.Content.ToString();
            }

            newNumber = 0;
        }

        
    }


    public enum SelectedOperator
    {
        Multiplication,
        Substraction,
        Addition,
        Division
    }


    public class SimpleMath
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Sustract(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double Multiplicate(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                MessageBox.Show("Division by 0 is not supprted", "Wrong oeration", MessageBoxButton.OK, MessageBoxImage.Warning);
                return 0;
            }

            return num1 / num2;
        }
    }

}
