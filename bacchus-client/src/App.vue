<template>
  <div id="app">
    <div  id="nav">
            <router-link to="/">Home</router-link> |
    </div>


  </div>


</template>

<script>
//import NavBar from './components/Nav/Navbar'


export default {
  name: 'App',
  components: {
    //NavBar
  }
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
