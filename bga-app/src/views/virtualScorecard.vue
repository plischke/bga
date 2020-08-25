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
                    <th> Hole </th>
                    <th class="text-center"  v-for="course in courseData" :key="course.holeID">{{course.description}}</th>
                </tr>
                <tr>
                    <th> Distance </th>
                    <th class="text-center"  v-for="course in courseData" :key="course.holeID">{{course.yardage}}yds</th>
                </tr>
                <tr>
                    <th> Par </th>
                    <th class="text-center"  v-for="course in courseData" :key="course.holeID">{{course.par}}</th>
                </tr>
            </thead>
            </template>
        </v-simple-table>
        <v-checkbox
            v-model="isNineRound"
            label="9 Round"
            ></v-checkbox>
            <v-checkbox
            v-model="isEighteenRound"
            label="18 Round"></v-checkbox>
        <v-form
        ref="form"
        v-model="valid"
        lazy-validation
        >
            <v-row>
                <v-select
                :items="playerList"
                label="Select player"
                v-model="playerSelected"
                item-text="name:"
                item-value="playerID:"
                ></v-select>
                <div v-if="isNineRound">
                    <p>Strokes</p>
                    <v-row>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole1"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole2"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole3"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole4"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole5"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole6"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole7"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole8"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole9"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                            </v-row>
                </div>
                <div v-if="isEighteenRound">
                            <p>Strokes</p>
                            <v-row>
                                <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole1"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole2"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole3"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole4"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole5"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole6"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole7"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole8"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole9"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole10"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole11"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole12"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole13"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole14"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole15"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole16"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole17"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    <v-col>
                        <v-text-field
                        outlined
                        label=""
                        v-model="hole18"
                        :rules="holeRule"
                        required></v-text-field>
                    </v-col>
                    </v-row>
                </div>
            </v-row>
            <v-btn color="error" @click="reset">Clear form</v-btn>
            <v-btn color="warning" @click="next" :disabled="!valid">Next Player</v-btn>
            <v-btn color="success" @click="submit" :disabled="!valid"> Submit</v-btn>
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
            selectedCourseID: null,
            courseData: [],
            players: [],
            playerSelected: null,
            selectedPlayerID: null,
            isNineRound: false,
            isEighteenRound: false,
            hole1:'',
            holeRule: [v => !!v || 'Strokes are required'],
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
            formdata: new FormData(),
            playerScores: [],
            valid: true

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
            this.selectedCourseID = id
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
        reset(){
            this.$refs.form.reset()
        },
        next(){
            if(this.isNineRound){
                this.playerScores.push({course:this.selectedCourse, courseID:this.selectedCourseID, isNineRound:this.isNineRound, isEighteenRound:this.isEighteenRound, player:this.playerSelected, score:{Hole1: this.hole1, Hole2:this.hole2,
             Hole3:this.hole3, Hole4: this.hole4, Hole5:this.hole5, Hole6: this.hole6, Hole7:this.hole7, Hole8: this.hole8, Hole9: this.hole9}})
            }
            if(this.isEighteenRound){
                this.playerScores.push({course:this.selectedCourse, courseID:this.selectedCourseID, isNineRound:this.isNineRound, isEighteenRound:this.isEighteenRound, player:this.playerSelected, score:{Hole1: this.hole1, Hole2:this.hole2,
             Hole3:this.hole3, Hole4: this.hole4, Hole5:this.hole5, Hole6: this.hole6, Hole7:this.hole7, Hole8: this.hole8, Hole9: this.hole9, Hole10: this.hole10, Hole11:this.hole11,
             Hole12: this.hole12, Hole13: this.hole13, Hole14: this.hole14, Hole15: this.hole15, Hole16: this.hole16, Hole17: this.hole17, Hole18: this.hole18}})
            }
            this.reset()
            console.log(this.playerScores)
        },
        submit(){
            if(this.isNineRound){
                this.playerScores.push({course:this.selectedCourse, courseID:this.selectedCourseID, isNineRound:this.isNineRound, isEighteenRound:this.isEighteenRound, player:this.playerSelected, score:{Hole1: this.hole1, Hole2:this.hole2,
             Hole3:this.hole3, Hole4: this.hole4, Hole5:this.hole5, Hole6: this.hole6, Hole7:this.hole7, Hole8: this.hole8, Hole9: this.hole9}})
            }
            if(this.isEighteenRound){
                this.playerScores.push({course:this.selectedCourse, courseID:this.selectedCourseID, isNineRound:this.isNineRound, isEighteenRound:this.isEighteenRound, player:this.playerSelected, score:{Hole1: this.hole1, Hole2:this.hole2,
             Hole3:this.hole3, Hole4: this.hole4, Hole5:this.hole5, Hole6: this.hole6, Hole7:this.hole7, Hole8: this.hole8, Hole9: this.hole9, Hole10: this.hole10, Hole11:this.hole11,
             Hole12: this.hole12, Hole13: this.hole13, Hole14: this.hole14, Hole15: this.hole15, Hole16: this.hole16, Hole17: this.hole17, Hole18: this.hole18}})
            }
            axios.post(CONSTANTS.BACK_END_CONNECTION_STRING+"coursescorecard", this.playerScores)
            .catch(error => {
                console.log(error)
            })
        },
        validate(){
            this.$refs.form.validate();
        }
    },
    computed:{
        playerList(){
            var playerlist = []
            for(let i =0; i<this.players.length; i++){
                playerlist.push({"playerID:":this.players[i].playerId, "name:":this.players[i].firstName+" "+this.players[i].lastName})
            }
            return playerlist;
        }
    }
}
</script>