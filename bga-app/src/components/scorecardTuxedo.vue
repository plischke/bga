<template>
<v-container>
    <!-- TODO: dynamically build virtual score card form based on response data-->
    <v-row>
        <v-col></v-col>
    </v-row>
</v-container>
</template>
<script>
export default {
    name:'scorecardTuxedo',
    data(){
        return{
        scorecard:[]
        }
    },
    methods:{
        fetchData(){
            axios.get(CONSTANTS.BACK_END_CONNECTION_STRING+"coursescorecard")
                .then((response) => {
                    this.scorecard = response.data
                })
                .catch((error) => {
                    console.log(error)
                });
        }
    }
}
</script>