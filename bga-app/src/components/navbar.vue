<template>
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
      <v-list-item v-for="link in links" :key="link.title" link  router :to="link.route">
        <v-list-item-content>
          <v-list-item-title>{{ link.title}}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
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