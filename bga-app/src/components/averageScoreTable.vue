<template>
<v-container fluid>
    <v-container fluid>
        <v-col sm="4">
            <v-select
            :items="items"
            label="Select course"
            dense
            outlined
            v-model="selectedTable">
            </v-select>
        </v-col>
    </v-container>
    <v-row  v-if="this.selectedTable === 'Tuxedo'">
        <v-col>
            <v-card color="teal lighten-1">
                <v-card-title>{{selectedTable}}</v-card-title>
                <averageScoreTuxedo/>
            </v-card>
        </v-col>
    </v-row>
    <v-row v-if="this.selectedTable === 'Canoe Club'">
        <v-col>
            <v-card color="green">
                <v-card-title>{{selectedTable}}</v-card-title>
                <averageScoreCC/>
            </v-card>
        </v-col>
    </v-row>
    <v-row v-if="this.selectedTable === 'Sandy Hook'">
        <v-col>
            <v-card color="yellow darken-3">
                <v-card-title>{{selectedTable}}</v-card-title>
                <averageScoreSandyHook/>
            </v-card>
        </v-col>
    </v-row>
    <v-row v-if="this.selectedTable === 'John Blumberg'">
        <v-col>
            <v-card color="blue-grey lighten-1">
                <v-card-title>{{selectedTable}}</v-card-title>
                <averageScoreJohnBlum/>
            </v-card>
        </v-col>
    </v-row>
    <v-row v-if="this.selectedTable === 'Assiniboine Golf Club'">
        <v-col>
            <v-card color="brown lighten-1">
                <v-card-title>{{selectedTable}}</v-card-title>
                <averageScoreAssiniboine/>
            </v-card>
        </v-col>
    </v-row>
    <div  v-if="this.selectedTable === 'All'">
    <v-row>
        <v-col>
            <v-card color="teal lighten-1">
                <v-card-title>Tuxedo</v-card-title>
            <averageScoreTuxedo/>
            </v-card>
        </v-col>
    </v-row>
    <v-row>
        <v-col>
            <v-card color="green">
                <v-card-title>Canoe Club</v-card-title>
                <averageScoreCC/>
            </v-card>
        </v-col>
        <v-col>
            <v-card color="yellow darken-3">
                <v-card-title>Sandy Hook</v-card-title>
            <averageScoreSandyHook/>
            </v-card>
        </v-col>
    </v-row>
    <v-row>
        <v-col>
            <v-card color="blue-grey lighten-1">
                <v-card-title>John Blumberg</v-card-title>
            <averageScoreJohnBlum/>
            </v-card>
        </v-col>
        <v-col>
            <v-card color="brown lighten-1">
                <v-card-title>Assiniboine Golf Club</v-card-title>
            <averageScoreAssiniboine/>
            </v-card>
        </v-col>
    </v-row>
    </div>
</v-container>
</template>
<script>
import averageScoreTuxedo from './averageScoreTuxedo.vue'
import averageScoreCC from './averageScoreCC.vue'
import averageScoreSandyHook from './averageScoreSandyHook.vue'
import averageScoreJohnBlum from './averageScoreJohnBlum.vue'
import averageScoreAssiniboine from './averageScoreAssiniboine.vue'

export default {
    name: 'averageScoreTable',
    components:{
        averageScoreTuxedo,
        averageScoreCC,
        averageScoreSandyHook,
        averageScoreJohnBlum,
        averageScoreAssiniboine
    },
    data(){
        return{
        items: ['All','Tuxedo', 'Canoe Club', 'Sandy Hook', 'John Blumberg', 'Assiniboine Golf Club'],
        selectedTable: null
        }
    },
    methods: {
    }
}
</script>