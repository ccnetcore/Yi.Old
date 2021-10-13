<template>
  <v-btn
    class="ml-3 mr-4"
    elevation="1"
    fab
    small
    @click="mini = !mini"
  >
    <v-icon>
      {{ mini ? 'mdi-format-list-bulleted' : 'mdi-dots-vertical' }}
    </v-icon>
  </v-btn>
</template>

<script>
  // Utilities
  // import { sync } from 'vuex-pathify'

  export default {
    data:()=>({
      mini:false
    }),
    name: 'DefaultDrawerToggle',

    computed: {

      // mini: sync('app/mini'),
    },
  }
</script>
