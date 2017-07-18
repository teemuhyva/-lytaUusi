using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace ÄlytaUusi {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Lights lights;
        Sauna sauna;
        Thermostat temperature;

        public MainWindow() {
            InitializeComponent();
            lights = new Lights();
            sauna = new Sauna(saunalampo, saunantila);
            temperature = new Thermostat(HaluttuLämpö, tavoite, nykyinentila);
            
        }

        //give lightState method 3 paramteres, 
        //first is dimmer, second is textbox for either livingroom or kitchen and third is textblock for livingroom or kitchen
        //livingroom lightswitches
        private void button_Click(object sender, RoutedEventArgs e) {
            //voiko switchediä tarkistaa toisesta classista onko on vai off
            //kannattaako joka button clickillä käydä laittamassa valot "on" asentoon vai kannattaako tarkistaa value?
            
            lights.LightsOff();
            lights.LightState(0, livingroom, livingRoomLight);
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            lights.LightsOn();
            lights.LightState(66, livingroom, livingRoomLight);
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            lights.LightsOn();
            lights.LightState(33, livingroom, livingRoomLight);
        }

        private void button3_Click_1(object sender, RoutedEventArgs e) {
            lights.LightsOn();
            lights.LightState(100, livingroom, livingRoomLight);
        }

        //kitchen light switches
        private void button8_Click(object sender, RoutedEventArgs e) {
            lights.LightsOn();
            lights.LightState(100, kitchen, kitchenlight);
        }

        private void button7_Click(object sender, RoutedEventArgs e) {
            lights.LightsOn();
            lights.LightState(66, kitchen, kitchenlight);
        }

        private void button6_Click(object sender, RoutedEventArgs e) {
            lights.LightsOn();
            lights.LightState(33, kitchen, kitchenlight);
        }

        private void button5_Click(object sender, RoutedEventArgs e) {
            lights.LightsOff();
            lights.LightState(0, kitchen, kitchenlight);
        }

        private void button4_Click(object sender, RoutedEventArgs e) {

            //get Swiched state from Sauna Class and mark Textblock either "Sauna päällä" if switched = true
            //otherwise clear textblock
            //check if ajastin textbox is writable, if is then it will take that value for start heating with timing
            if(sauna.Switched == false) {
                sauna.SaunaOn();

                //send UI time to delayed start method so sauna won't start instantly
                if(ajastin.IsReadOnly == false) {
                    saunantila.Text = "Lämmitys alkaa " + ajastin.Text + "s päästä";
                    sauna.DelayedStart(Int32.Parse(ajastin.Text) * 1000);
                } else {
                    saunantila.Text = "Sauna päällä";
                    sauna.StartTimer();
                }
                
            } else {
                sauna.SaunaOff();
                saunantila.Text = "";
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e) {
            temperature.Temprature = Int32.Parse(tavoite.Text);
            int wantedTemp = temperature.Temprature;
            temperature.SetTemp(wantedTemp);
        }

        private void tavoite_GotFocus(object sender, RoutedEventArgs e) {
            if(tavoite.Text != "") {
                tavoite.Text = "";
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e) {
            if(checkBox.IsChecked == true) {
                ajastin.IsReadOnly = false;
            } 
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e) {
            if(checkBox.IsChecked == false) {
                ajastin.IsReadOnly = true;
            }
        }
    }
}
