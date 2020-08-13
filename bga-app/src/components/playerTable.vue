<template>
<v-simple-table class="elevation-1" fixed-header height=300>
    <template v-slot:default>
        <thead>
            <tr>
                <th class="text-center"  v-for="header in headers" :key="header.text">{{header.text}}</th>
            </tr>
        </thead>
        <tbody>
            <tr class="text-center" v-for="player in players" :key="player.playerId">
                <td>{{player.firstName}}</td>
                <td>{{player.lastName}}</td>
                <td>{{player.avg}}</td>
                <td>{{player.roundsPlayed}}</td>
            </tr>
        </tbody>
    </template>
</v-simple-table>
</template>

<script>
    import axios from 'axios'
    import CONSTANTS from '../constants'
    export default{
        name: 'playerTable',
        data(){
            return{
                headers:[
                    {
                        text:'First Name',
                    },
                    {
                        text:'Last Name'
                    },
                    {   text:'Average'
                    },
                    {
                        text: 'Total Rounds Played'
                    }

                ],
                players:[]
            }
        },
        created(){
            this.fetchData();
        },
        methods:{
            fetchData(){
                axios.get(CONSTANTS.BACK_END_CONNECTION_STRING+"players")
                .then((response) =>{
                    this.players=response.data
                })
                .catch((error) =>{
                console.log(error)
            });
        }
    }
    }
</script>