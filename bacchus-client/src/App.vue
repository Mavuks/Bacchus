<template>
  <div id="app">
    <NavBar/>
    <router-view/>
  </div>
</template>

<script>

import NavBar from '../src/components/Nav/Navbar'


export default {
  name: 'App',
  components: {
    NavBar
  },
}
</script>

<style>

@import "https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css";


#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
