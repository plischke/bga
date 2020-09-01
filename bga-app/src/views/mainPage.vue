<template>
<div>
    <v-carousel
    cycle
    height="800"
    show-arrows-on-hover
    hide-delimiter-background
    >
        <v-carousel-item
        v-for="(item, i) in items"
        :key="i"
        :src="item.src"
        >
    </v-carousel-item>
  </v-carousel>
<v-card
    color="indigo darken-2"
    >
        <v-container fluid>
            <v-row>
                <v-col align="center">
                <v-card max-width="800" color="orange darken-4">
                    <v-card-title>All BGA Players</v-card-title>
                <playerTable/>
                </v-card>
            </v-col>
            <v-col align="center">
                <v-card max-width="800" color="orange darken-4">
                    <v-card-title>All BGA Sanctioned Courses</v-card-title>
                <courseTable/>
                </v-card>
            </v-col>
            </v-row>
            <v-row>
                <v-col>
                <v-card>
                    <v-card-title>Average Scores Of Players Per Course</v-card-title>
                    <averageScoreTable/>
                </v-card>
            </v-col>
            </v-row>
        </v-container>
</v-card>
</div>
</template>

<script>
    import playerTable from '../components/playerTable.vue'
    import courseTable from '../components/courseTable.vue'
    import averageScoreTable from '../components/averageScoreTable.vue'
    export default {
        name:'mainPage',
        components:{
            playerTable,
            courseTable,
            averageScoreTable,
        },
        data(){
            return{
                items: [
                    {
                        src: require("../assets/background.jpg")
                    },
                ]
            }
        }
    }
</script>
