<template>
    <v-card>
        <v-card-title>Virtual scorecard</v-card-title>
        <v-select
            :items="items"
            label="Select course"
            dense
            outlined
            v-model="selectedCourse">
            </v-select>
            <v-row>
            <v-col>Hole</v-col>
            <v-col>1</v-col>
            <v-col>2</v-col>
            </v-row>
    </v-card>
</template>
<script>
export default {
    name:'virtualScorecard',
    data(){
        return{
            items:['Tuxedo','Canoe Club', 'Sandy Hook', 'John Blumberg', 'Assiniboine Golf Club'],
            selectedCourse: null
        }
    },
}
</script>