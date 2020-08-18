<template>
    <v-card>
        <v-card-title>Virtual scorecard</v-card-title>
        <v-select
            :items="items"
            item-text="name"
            label="Select course"
            dense
            outlined
            v-model="selectedCourse"
            @input="courseSelect"
            >
            </v-select>
            <v-container>
                <h1>{{selectedCourse}}</h1>
        <v-simple-table class="elevation-1" fixed-header height=200>
            <template v-slot:default>
            <thead>
                <tr>
                    <th class="text-center"  v-for="course in courseData" :key="course.holeID">{{course.description}}</th>
                </tr>
                <tr>
                    <th class="text-center"  v-for="course in courseData" :key="course.holeID">{{course.yardage}}</th>
                </tr>
                <tr>
                    <th class="text-center"  v-for="course in courseData" :key="course.holeID">{{course.par}}</th>
                </tr>
            </thead>
            </template>
        </v-simple-table>
        <!--TODO: create function to push form data to an array to allow inserts for each player per round, then write function to push form data array to backend -->
        <v-form>
            <v-checkbox
            v-model="isNineRound"
            label="9 Round"
            ></v-checkbox>
            <v-checkbox
            v-model="isEighteenRound"
            label="18 Round"></v-checkbox>
            <v-row>
                <v-select
                :items="playerList"
                label="Select player"
                v-model="playerSelected"
                item-text="name:"></v-select>
                <div v-if="isNineRound">
                    <p>Strokes</p>
                    <v-row>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole1"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole2"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole3"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole4"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole5"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole6"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole7"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole8"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole9"></v-text-field>
            </v-col>
                    </v-row>
                </div>
                <div v-if="isEighteenRound">
                    <p>Strokes</p>
                    <v-row>
                        <v-col>
                <v-text-field
                label="strokes"
                v-model="hole1"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole2"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole3"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole4"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole5"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole6"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole7"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole8"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole9"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole10"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole11"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole12"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole13"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole14"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole15"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole16"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole17"></v-text-field>
            </v-col>
            <v-col>
                <v-text-field
                label="strokes"
                v-model="hole18"></v-text-field>
            </v-col>
            </v-row>
                </div>
            </v-row>
            <v-btn color="error" @click="clear">Clear form</v-btn>
            <v-btn color="success">Next Player</v-btn>
        </v-form>

            </v-container>
    </v-card>
</template>
<script>
import axios from 'axios'
import CONSTANTS from '../constants'
export default {
    name:'virtualScorecard',
    data(){
        return{
            items:[{name:'Tuxedo', id:'1'},{name:'Canoe Club',id:'2'}, {name:'Sandy Hook', id:'3'}, {name:'John Blumberg', id:'4'}, {name:'Assiniboine Golf Club',id:'5'}],
            selectedCourse: null,
            courseData: [],
            players: [],
            playerSelected: null,
            hole1:'',
            hole2:'',
            hole3:'',
            hole4:'',
            hole5:'',
            hole6:'',
            hole7:'',
            hole8:'',
            hole9:'',
            hole10:'',
            hole11:'',
            hole12:'',
            hole13:'',
            hole14:'',
            hole15:'',
            hole16:'',
            hole17:'',
            hole18:'',
            isNineRound: false,
            isEighteenRound: false
        }
    },
    created(){
        this.fetchPlayers();
    },
    methods:{
        fetchData(id){
                axios.get(CONSTANTS.BACK_END_CONNECTION_STRING+"coursescorecard/"+id)
                .then((response) => {
                    this.courseData = response.data
                })
                .catch((error) => {
                    console.log(error)
                });
        },
        courseSelect(event){
            var id
            this.selectedCourse = event;
            for(let i = 0; i<this.items.length; i++){
                if(this.selectedCourse === this.items[i].name){
                    id = this.items[i].id
                }
            }
            this.fetchData(id);
        },
        fetchPlayers(){
            axios.get(CONSTANTS.BACK_END_CONNECTION_STRING+"players")
            .then((response) => {
                this.players = response.data
            })
            .catch((error) => {
                console.log(error)
            });
        },
        clear(){
            this.$refs.form.reset()
        }
    },
    computed:{
        playerList(){
            var playerlist = []
            for(let i =0; i<this.players.length; i++){
                playerlist.push({"playerID":this.players[i].playerId, "name:":this.players[i].firstName+" "+this.players[i].lastName})
            }
            return playerlist;
        }
    }
}
</script>