// Vuetify Documentation https://vuetifyjs.com

import Vue from 'vue'
import Vuetify from 'vuetify/lib/framework'
import ripple from 'vuetify/lib/directives/ripple'

Vue.use(Vuetify, { directives: { ripple } })

const theme = {
    primary: '#E91E63',
    secondary: '#9C27b0',
    accent: '#e91e63',
    info: '#00CAE3',
    success: '#4CAF50',
    warning: '#FB8C00',
    error: '#FF5252',
}

export default new Vuetify({
    breakpoint: { mobileBreakpoint: 960 },
    icons: {
        values: { expand: 'mdi-menu-down' },
    },
    theme: {
        themes: {
            dark: theme,
            light: theme,
        },
    },
})