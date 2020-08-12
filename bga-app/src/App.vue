<template>
  <v-app id="app">
    <navbar />
    <v-parallax
      height="800"
      src="./assets/background.jpg">
    </v-parallax>
    <mainPage/>
  </v-app>
</template>

<script>
import mainPage from './components/mainPage.vue';
import navbar from './components/navbar.vue';

export default {
  name: 'app',

  components: {
    mainPage,
    navbar
  }
}
</script>
<style src="@/global-style.css"/>
