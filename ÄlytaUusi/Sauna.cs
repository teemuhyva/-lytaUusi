using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ÄlytaUusi {
    public class Sauna {

        DispatcherTimer dispacherTimer;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        TextBlock heat;
        TextBlock saunantila;

        private int counter = 20;
        private int unicode = 176;
        char celsius;

        public Sauna() {
        }

        public Sauna(TextBlock heat, TextBlock saunantila) {
            this.heat = heat;
            this.saunantila = saunantila;
        }

        public Boolean Switched {
            get; set;
        }

        public Boolean SwitchedHeating {
            get; set;
        }
        
        public void SaunaOff() {
            Switched = false;
        }

        public void SaunaOn() {
            Switched = true;
            SwitchedHeating = true;
            celsius = (char)unicode;
            heat.Text = counter.ToString() + celsius;
        }

        //use delayed start if checkbox is checked
        //parameter takes time for seconds and multiplies that by * 1000
        public async void DelayedStart(int ajastin) {

            await Task.Delay(ajastin, tokenSource.Token);
            saunantila.Text = "Sauna päällä";

            StartTimer();
        }


        //dispatcher timer for running sauna temp
        public void StartTimer() {
            dispacherTimer = new DispatcherTimer();
            dispacherTimer.Interval = TimeSpan.FromSeconds(0.5);
            dispacherTimer.Tick += InCreaseSaunaTemp;
            dispacherTimer.Start();
        }
        
        public void InCreaseSaunaTemp(object sender, EventArgs e) {
            

            //as long as Swicthed is on sauna will be on and this if section will run
            //SwitchedHeating is for if sauna reaches max level of heat it will be turned off and sauna temp will dicrese
            //when it's decreased to min level switchheating will turn on again
            if(Switched != false) {
                if(counter <= 30 && SwitchedHeating == true) {
                    counter++;
                } else if(counter <= 22) {
                    counter--;
                    SwitchedHeating = true;
                } else {
                    SwitchedHeating = false;
                    counter--;
                }

            //when sauna switched off sauna temp will decrease to level of apartment temperature
            //when that leve is reached timer will stop 
            } else {
                if(counter > 20) {
                    counter--;
                } else {
                    dispacherTimer.Stop();
                    dispacherTimer = null;
                }
            }

            celsius = (char)unicode;
            heat.Text = counter.ToString() + celsius.ToString();
            
        }
    }
}
