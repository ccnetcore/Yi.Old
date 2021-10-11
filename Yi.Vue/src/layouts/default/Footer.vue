<template>
  <v-footer
    id="default-footer"
    color="transparent"
    absolute
    app
    inset
  >
    <links />
  </v-footer>
</template>

<script>
  // Components
  import Links from '@/components/Links'

  export default {
    name: 'DefaultFooter',

    components: { Links },
  }
</script>
