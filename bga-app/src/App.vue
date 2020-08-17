<template>
  <v-app id="app">

<!-- navbar here to allow dynamic render based on the page selected -->
    <div>
    <v-app-bar
    color = "deep-purple accent-4"
    dense
    dark>
    <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    <v-toolbar-title>Official BGA App</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer app v-model="drawer" absolute temporary>
      <v-list-item-content>Menu</v-list-item-content>
      <v-divider></v-divider>
      <v-list>
      <v-list-item v-for="link in links" :key="link.title" link @click="pageChange(link.title)">
        <v-list-item-content>
          <v-list-item-title>{{ link.title}}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </div>

<!-- displays main page-->
  <div v-if="this.selectedPage ==='Home'">
    <v-parallax
      height="690"
      src="./assets/background.jpg"
      fixed
      >
    </v-parallax>
    <mainPage/>
  </div>
  <!-- displays scorecard page to allow scores to be entered and submitted to backend-->
  <div v-if="this.selectedPage === 'Submit Score'">
  <virtualScorecard/>
  </div>

  </v-app>
</template>

<script>
import mainPage from './views/mainPage.vue';
import virtualScorecard from './views/virtualScorecard.vue'
export default {
  name: 'app',

  components: {
    mainPage,
    virtualScorecard
  },
  data(){
    return{
      drawer:false,
      links: [
        {title: 'Home'},
        {title: 'Submit Score' }
      ],
      selectedPage: 'Home'
    }
  },
  methods:{
    pageChange(page){
      this.selectedPage = page;
    }
  }
}
</script>
<style src="@/global-style.css"/>
