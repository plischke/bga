<template>
    <v-simple-table class="elevation-1" fixed-header height=300 >
    <template v-slot:default>
    <thead>
        <tr>
        <th class="text-center">Course Name</th>
        <th class="text-center">Par</th>
        </tr>
    </thead>
    <tbody>
        <tr v-for="course in courses" :key="course.courseID">
        <td>{{ course.courseName }}</td>
        <td>{{ course.par }}</td>
        </tr>
    </tbody>
    </template>
    </v-simple-table>
</template>

<script>
    import axios from 'axios'
    import CONSTANTS from '../constants'
    export default{
        name: 'courseTable',
        data(){
            return{
                courses:[]
            }
        },
        created(){
            this.fetchData();
        },
        methods:{
            fetchData(){
                axios.get(CONSTANTS.BACK_END_CONNECTION_STRING+"courses")
                .then((response) =>{
                    this.courses=response.data
                })
                .catch((error) =>{
                console.log(error)
            });
            }
        }
    }
</script>