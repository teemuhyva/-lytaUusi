using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ÄlytaUusi {
    class Thermostat {

        DispatcherTimer dispacherTimer;
        TextBlock haluttuLampo;
        TextBox tavoite;
        TextBlock nykyinentila;

        int unicode = 176;        
        private int counter;
        
        public Thermostat() {
        }
        
        public Thermostat(TextBlock haluttuLampo, TextBox tavoite, TextBlock nykyinentila) {
            this.haluttuLampo = haluttuLampo;
            this.tavoite = tavoite;
            this.nykyinentila = nykyinentila;
        }

        public int Temprature {
            get; set;
        }


        //assign new temperature. method takes parameters from textbox for wanted temp and TextBlock and textbox so 
        //you can easily reference those windows components
        //note. integer will be changed to text when assigning new value
        public void SetTemp(int wantedTemp) {
            char celsius = (char)unicode;
            haluttuLampo.Text = wantedTemp.ToString() + celsius.ToString();
            tavoite.Text = "";
            StartTimer();
        }

        public void StartTimer() {
            dispacherTimer = new DispatcherTimer();
            dispacherTimer.Interval = TimeSpan.FromSeconds(0.5);
            dispacherTimer.Tick += ApartmentTemperature;
            dispacherTimer.Start();
        }

        private void ApartmentTemperature(object sender, EventArgs e) {

            string nykyinen;
            string haluttu;

            if(haluttuLampo.Text.Length < 2) {
                haluttu = haluttuLampo.Text = "1";
            } else {
                haluttu = haluttuLampo.Text.Remove(haluttuLampo.Text.Length - 1);
            }

            if(nykyinentila.Text.Length < 2) {
                nykyinen = nykyinentila.Text = "1";

            } else {
                nykyinen = nykyinentila.Text.Remove(nykyinentila.Text.Length - 1);
            }
            
            int current = Int32.Parse(nykyinen);
            int wanted = Int32.Parse(haluttu);
            char celsius = (char)unicode;

            if(current < wanted) {
                counter++;
            } else if(current > wanted) {
                counter--;
            } else {
                dispacherTimer.Stop();
                dispacherTimer = null;
                Temprature = Int32.Parse(nykyinen);
            }

            nykyinentila.Text = counter.ToString() + celsius.ToString();
            
        }
        
    }
}
