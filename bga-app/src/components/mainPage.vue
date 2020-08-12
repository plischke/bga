<template>

        <v-container fluid>
            <v-row>
                <v-col>
                <v-card max-width="800">
                    <v-card-title>All BGA Players</v-card-title>
                <playerTable/>
                </v-card>
            </v-col>
            <v-col>
                <v-card>
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

</template>

<script>
    import playerTable from './playerTable.vue'
    import courseTable from './courseTable.vue'
    import averageScoreTable from './averageScoreTable.vue'
    export default {
        name:'mainPage',
        components:{
            playerTable,
            courseTable,
            averageScoreTable
        }
    }
</script>
