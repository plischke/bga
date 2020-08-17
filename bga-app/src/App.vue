<template>
  <v-app id="app">
    <navbar/>
  <router-view/>
  </v-app>
</template>

<script>
import navbar from './components/navbar.vue'
export default {
  name: 'app',

  components: {
    navbar
  }
}
</script>
<style src="@/global-style.css"/>
