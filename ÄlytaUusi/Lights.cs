using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ÄlytaUusi {
    public class Lights {

        ColorPickUp pickedColor = new ColorPickUp();
        SolidColorBrush brush;
        
        private Boolean Switched {
            get; set;
        }

        private String Dimmer {
            get; set;
        }
        

        public void LightsOn() {
            Switched = true;
        }

        public void LightsOff() {
            Switched = false;
        }

        //textbox and texblock values coming from mainwindow depending do we click button for li
        public void LightState(int state, TextBox livingRoomOrKitchenTxtBx, TextBlock livingRoomOrKitchenTxtBlc) {
            Dimmer = state.ToString();

            //käy hakemassa oikat värit valoille
            switch(Dimmer) {
                case "0":               
                    brush = new SolidColorBrush(pickedColor.colorBursh(255, 255, 255));
                    livingRoomOrKitchenTxtBx.Background = brush;
                    livingRoomOrKitchenTxtBlc.Text = "Valot pois";
                    break;
                case "33":
                    brush = new SolidColorBrush(pickedColor.colorBursh(255, 255, 204));
                    livingRoomOrKitchenTxtBx.Background = brush;
                    livingRoomOrKitchenTxtBlc.Text = "Himmeä";
                    break;
                case "66":
                    brush = new SolidColorBrush(pickedColor.colorBursh(255, 255, 153));
                    livingRoomOrKitchenTxtBx.Background = brush;
                    livingRoomOrKitchenTxtBlc.Text = "Puolivalot";
                    break;
                case "100":
                    brush = new SolidColorBrush(pickedColor.colorBursh(255, 255, 102));
                    livingRoomOrKitchenTxtBx.Background = brush;
                    livingRoomOrKitchenTxtBlc.Text = "Kirkas";
                    break;
            }
        }

        
    }
}
