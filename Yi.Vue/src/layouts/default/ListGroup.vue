<template>
  <v-list-group
   
:group="group"
    :prepend-icon="item.icon"
    eager
    v-bind="$attrs"
  >
    <template v-slot:activator>
      <v-list-item-icon
        v-if="!item.icon && !item.avatar"
        class="text-caption text-uppercase text-center my-2 align-self-center"
        style="margin-top: 14px"
      >
        {{ title }}
      </v-list-item-icon>

      <v-list-item-avatar v-if="item.avatar">
        <v-img :src="item.avatar" />
      </v-list-item-avatar>

      <v-list-item-content v-if="item.menu_name">
        <v-list-item-title v-text="item.menu_name" />
      </v-list-item-content>
    </template>

    <template v-for="(child, i) in item.children">
      <default-list-group
        v-if="child.children"
        :key="`sub-group-${i}`"
        :item="child"
      />

      <default-list-item
        v-if="!child.children"
        :key="`child-${i}`"
        :item="child"
      />
    </template>
  </v-list-group>
</template>

<script>
  // Utilities
  // import { get } from 'vuex-pathify'

  export default {
    name: 'DefaultListGroup',

    components: {
      DefaultListItem: () => import('./ListItem'),
    },

    props: {
      item: {
        type: Object,
        default: () => ({}),
      },
    },

    computed: {
 
      group () {
        return this.genGroup(this.item.children)
      },
      title () {
        const matches = this.item.menu_name.match(/\b(\w)/g)
if(matches!=null)
{
        return matches.join('')
}
      },
    },

    methods: {
      genGroup (items) {
        return items.reduce((acc, cur) => {
          if (!cur.router) return acc

          acc.push(
            cur.children
              ? this.genGroup(cur.children)
              : cur.router.slice(1, -1),
          )

          return acc
        }, []).join('|')
      },
    },
  }
</script>
