<template>
<div>
    <v-app-bar
    color = "deep-purple accent-4"
    dense
    fixed
    dark>
    <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    <v-img src="../../public/favicon.png" max-width="45" max-height="45"/>
    <v-toolbar-title>Official BGA App</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer app v-model="drawer" fixed temporary color="blue-grey lighten-4">
      <v-list-item-content class="justify-center">Menu</v-list-item-content>
        <v-divider></v-divider>
          <v-list>
            <v-list-item-group active-class="deep-purple--text" >
              <v-list-item v-for="link in links" :key="link.title" link  router :to="link.route" >
                  <v-list-item-title>{{link.title}}</v-list-item-title>
              </v-list-item>
            </v-list-item-group>
          </v-list>
    </v-navigation-drawer>
</div>
</template>
<script>
export default {
    name:'navbar',
    data(){
    return{
      drawer:false,
      links: [
        {title: 'Home', route:'/'},
        {title: 'Submit Score', route:'/scorecard' }
      ],
      selectedPage: 'Home'
    }
    }
}
</script>