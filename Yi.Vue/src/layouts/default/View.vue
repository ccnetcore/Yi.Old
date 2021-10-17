<template>
  <v-main>
    <v-container fluid>
          <v-progress-linear
      :active="this.$store.state.loader.load"
      :indeterminate="this.$store.state.loader.load"
      background-color="primary lighten-4"
      color="primary lighten-1"
      striped
    ></v-progress-linear>
      <router-view :key="$route.path" />
    </v-container>
  </v-main>
</template>

<script>
  export default {
    name: 'DefaultView',
  }
</script>
