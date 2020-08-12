<template>
<v-container fluid>
    <v-row>
        <v-col>
            <v-card>
                <v-card-title>Tuxedo</v-card-title>
            <averageScoreTuxedo/>
            </v-card>
        </v-col>
        <v-col>
            <v-card>
                <v-card-title>Canoe Club</v-card-title>
                <averageScoreCC/>
            </v-card>
        </v-col>
    </v-row>
</v-container>
</template>
<script>
import averageScoreTuxedo from './averageScoreTuxedo.vue'
import averageScoreCC from './averageScoreCC.vue'
export default {
    name: 'averageScoreTable',
    components:{
        averageScoreTuxedo,
        averageScoreCC
    }
}
</script>