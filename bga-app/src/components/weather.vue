<template> 
<div>
    <p>Currently Feels Like: {{}}</p>
</div>
</template>
<script>
import axios from 'axios'
import CONSTANTS from '../constants'
export default {
    name: 'weather',
    data(){
        return{
            lon: null,
            lat: null,
            weatherData: null,
        }
    },
    created(){
        //this.getLocation();
    },
    methods:{
        fetchWeather(){
            axios.get("http://api.openweathermap.org/data/2.5/weather?lat="+this.lat+"&lon="+this.lon+"&units=metric"+"&appid="+CONSTANTS.APIKEY)
            .then((response) => {
                this.weatherData = response.data
                console.log(this.weatherData)
            })
            .catch((error) => {
                console.log(error)
            });
        },
        getLocation(){
            if(navigator.geolocation){
                navigator.geolocation.getCurrentPosition(pos =>{
                    this.lon = pos.coords.longitude
                    this.lat = pos.coords.latitude
                    this.fetchWeather();
                });
            }
        }
    }
}
</script>