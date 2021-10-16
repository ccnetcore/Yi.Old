<template>
  <v-btn
    class="ml-3 mr-4"
    elevation="1"
    fab
    small
    @click="$store.state.home.mini = !$store.state.home.mini"
  >
    <v-icon>
      {{ $store.state.home.mini ? 'mdi-format-list-bulleted' : 'mdi-dots-vertical' }}
    </v-icon>
  </v-btn>
</template>

<script>
  // Utilities
  // import { sync } from 'vuex-pathify'

  export default {

    data:()=>({
     
    }),
    name: 'DefaultDrawerToggle',

    computed: {

      // mini: sync('app/mini'),
    },
  }
</script>
