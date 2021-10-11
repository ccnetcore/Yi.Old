<template>
  <default-list
    :items="items"
    class="mb-n2"
  />
</template>

<script>
  export default {
    name: 'DefaultAccountSettings',

    components: {
      DefaultList: () => import(
        /* webpackChunkName: "default-list" */
        '../List'
      ),
    },

    data: () => ({
      items: [
        {
          title: 'John Leider',
          icon: 'mdi-vuetify',
          items: [
            {
              title: 'My Profile',
            },
            {
              title: 'Edit Profile',
            },
            {
              title: 'Settings',
            },
          ],
        },
      ],
    }),
  }
</script>
