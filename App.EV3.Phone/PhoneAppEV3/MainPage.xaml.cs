using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneAppEV3.Resources;
using Lego.Ev3.Core;
using Lego.Ev3.Phone;

namespace PhoneAppEV3
{
    public partial class MainPage : PhoneApplicationPage
    {
        Brick brick = new Brick(new NetworkCommunication("192.168.2.7"));
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        
        private async void button_go_Click(object sender, RoutedEventArgs e)
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 30, 500, 5000, 200, false);
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 30, 500, 5000, 200, false);
            await brick.BatchCommand.SendCommandAsync();
            while (true)
            {
                brick.BatchCommand.PlayTone(100, 1500, 500);
                await brick.BatchCommand.SendCommandAsync();
                return;
            }
        }

        private async void button_back_Click(object sender, RoutedEventArgs e)
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, -30, 500, 5000, 200, false);
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, -30, 500, 5000, 200, false);
            await brick.BatchCommand.SendCommandAsync();
            while (true)
            {
                brick.BatchCommand.PlayTone(100, 1500, 500);
                await brick.BatchCommand.SendCommandAsync();
                return ;
            }
        }

        private async void button_left_Click(object sender, RoutedEventArgs e)
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 0, 1000, false);
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 30, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
            while (true)
            {
                brick.BatchCommand.PlayTone(100, 1500, 500);
                await brick.BatchCommand.SendCommandAsync();
                return;
            }
        }

        private async void button_right_Click(object sender, RoutedEventArgs e)
        {
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.B, 30, 1000, false);
            brick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.C, 0, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
            while (true)
            {
                brick.BatchCommand.PlayTone(100, 1500, 500);
                await brick.BatchCommand.SendCommandAsync();
                return;
            }
        }

        private void PlaySounds_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PlaySounds.xaml", UriKind.Relative));

        }

        private void main_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            await brick.ConnectAsync();
        }

        private async void PhoneApplicationPage_Unloaded(object sender, RoutedEventArgs e)
        {
            brick.Disconnect();
            await brick.BatchCommand.SendCommandAsync();
        }

        
        // Sample code for building a localized ApplicationBar

    }
}