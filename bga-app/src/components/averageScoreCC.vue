<template>
<v-simple-table class="elevation-1" fixed-header height=300>
    <template v-slot:default>
        <thead>
            <tr>
                <th class="text-center"  v-for="header in headers" :key="header.text">{{header.text}}</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="player in averagesForCanoeClub" :key="player.playerId">
                <td>{{player.firstName}}</td>
                <td>{{player.lastName}}</td>
                <td>{{player.average}}</td>
            </tr>
        </tbody>
    </template>
</v-simple-table>
</template>
<script>
import axios from 'axios'
import CONSTANTS from '../constants'
export default {
    name: 'averageScoreCC',
    data(){
        return{
            headers: [
                {
                    text:"First Name"
                },
                {
                    text:"Last Name"
                },
                {
                    text:"Average"
                }
            ],
            scores: [],
        }
    },
    //take the array of scores from db and seperate them individually by course
    computed:{
        averagesForCanoeClub(){
            var course = []
            for(let i = 0; i<this.scores.length; i++){
                if(this.scores[i].courseName === 'Canoe Club'){
                    course.push({"playerId":this.scores[i].playerId,"firstName":this.scores[i].firstName, "lastName":this.scores[i].lastName, "average":this.scores[i].average});
                }
            }
            return course;
        }
    },
        created(){
            this.fetchData();
        },
        methods:{
            fetchData(){
                axios.get(CONSTANTS.BACK_END_CONNECTION_STRING+"averagescorepercourse")
                .then((response) => {
                    this.scores = response.data
                })
                .catch((error) => {
                    console.log(error)
                });
            } 
        }
}
</script>