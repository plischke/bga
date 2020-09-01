<template>
<div>
    <v-app-bar
    color = "deep-purple accent-4"
    dense
    fixed
    dark>
    <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    <v-img src="../../public/favicon.png" max-width="45" max-height="45"/>
    <v-toolbar-title>Official BGA App</v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-title v-if="hasData">Todays Temperature: {{this.weatherData.main.temp}}°C, Conditions: {{this.weatherData.weather[0].description}}</v-toolbar-title>
    <v-img :src='this.weatherIcon' max-width="45" max-height="45"/>
    <v-spacer></v-spacer>
    <v-toolbar-title v-if="hasData">Currently Feels Like: {{this.weatherData.main.feels_like}}°C</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer app v-model="drawer" fixed temporary color="blue-grey lighten-4">
      <v-list-item-content class="justify-center">Menu</v-list-item-content>
        <v-divider></v-divider>
          <v-list>
            <v-list-item-group active-class="deep-purple--text" >
              <v-list-item v-for="link in links" :key="link.title" link  router :to="link.route" >
                  <v-list-item-title>{{link.title}}</v-list-item-title>
              </v-list-item>
            </v-list-item-group>
          </v-list>
    </v-navigation-drawer>
</div>
</template>
<script>
import axios from 'axios'
import CONSTANTS from '../constants'
export default {
    name:'navbar',
    components:{
    },
    data(){
    return{
      lon: null,
      lat: null,
      weatherData: null,
      hasLocation: false,
      hasData: false,
      drawer:false,
      weatherIcon: null,
      links: [
        {title: 'Home', route:'/'},
        {title: 'Submit Score', route:'/scorecard' }
      ],
      selectedPage: 'Home'
      }
    },
    created(){
      this.getLocation();
    },
    methods:{
      getLocation(){
          if(navigator.geolocation){
            navigator.geolocation.getCurrentPosition(pos =>{
              this.lon = pos.coords.longitude;
              this.lat = pos.coords.latitude;
              this.hasLocation = true;
              this.fetchWeather();
              });
            }
        },
      fetchWeather(){
        if(this.hasLocation){
          axios.get("http://api.openweathermap.org/data/2.5/weather?lat="+this.lat+"&lon="+this.lon+"&units=metric"+"&appid="+CONSTANTS.APIKEY)
            .then((response) => {
              this.weatherData = response.data;
              this.hasData = true;
              this.weatherIcon =  'http://openweathermap.org/img/wn/'+this.weatherData.weather[0].icon+'@2x.png'
            })
            .catch((error) => {
             console.log(error);
            });
        }
        },
    }
}
</script>