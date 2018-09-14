<template>
    <div>
        <md-dialog :md-active.sync="this.$store.state.Auth.NeedLogin" :md-click-outside-to-close="false">
            <md-dialog-title>Iniciar sesión</md-dialog-title>
            <md-content class="igs-login">
            <form>
                <md-field :class="messageClass" md-clearable>
                    <label>Usuario</label>
                    <md-input v-model="loginData.User"></md-input>
                    <span class="md-error">There is an error</span>
                </md-field>
                <md-field :class="messageClass">
                    <label>Contraseña</label>
                    <md-input v-model="loginData.Pass" type="password"></md-input>
                    <span class="md-error">There is an error</span>
                </md-field>
            </form>
            </md-content>
            <md-dialog-actions>
                <md-button class="md-primary" @click.prevent="login">iniciar</md-button>
            </md-dialog-actions>
        </md-dialog>
        <router-view v-if="!this.$store.state.Auth.NeedLogin" />
    </div>
</template>

<style lang="scss">
@import './styles/fonts.css';
@import "~vue-material/dist/theme/engine"; // Import the theme engine

body {
    font-family: 'product_sansregular';
    color: md-get-palette-color(grey, 800) !important;
}

#logo {
    max-height: 96px;
    margin: 0 24px;
}
.md-content.igs-login{
    padding: 0 24px;
}
.md-app {
    border: 1px solid rgba(#000, .12);
    width: 100%;
    height: 100%;
    position: absolute !important;
}

// Demo purposes only
.md-drawer {
    width: 230px;
}

.page-container {
    position: relative;
    height: 100%;
}

.md-toolbar.md-theme-default.md-primary {
    background-color: white !important;
}

.md-tabs.md-theme-default.md-primary .md-tabs-navigation {
    background-color: white !important;
}

.md-toolbar.md-theme-default.md-primary .md-button:not([disabled]):not(.md-raised) {
    color: #000 !important;
}

.md-tabs-indicator {
    background-color: md-get-palette-color(blue, A200) !important;
}

.md-title {
    color: md-get-palette-color(grey, 800) !important;
}

.md-drawer {
    border: 0 solid transparent !important;
}

.md-content.igs-app {
    border: 0 solid transparent !important;
    padding: 0 16px 16px 10px !important;
}

.md-drawer {
    .md-icon {
        color: md-get-palette-color(grey, 800) !important;
    }

    width: 260px !important;

    .md-list {
        padding: 0 0 16px 0 !important;
    }

    .md-list-item-router {
        padding: 4px 15px 4px 15px !important;
        margin: 0 0 0 1px;
    }

    .md-list-item-router:hover {
        background-color: transparent !important;

        .md-list-item-content {
            background-color: md-get-palette-color(grey, 100)
        }
    }

    .md-list-item-content {
        padding: 0px 10px 0px 8px !important;
        min-height: 40px !important;
        border-radius: 20px;
    }

    .router-link-active {
        .md-list-item-content {
            background: md-get-palette-color(blue, 100) !important;
            color: md-get-palette-color(blue, A200) !important;

            .md-icon {
                color: md-get-palette-color(blue, A200) !important;
            }
        }
    }
}

@media (max-width: 960px) {
    .md-toolbar {
        padding: 0 16px !important;
        min-height: 64px !important;
    }

    .md-title {
        margin-left: 24px !important;
    }
}
</style>

<script>
function SetViewPort(store){
    let innerWidth = window.innerWidth
    let innerHeight = window.innerHeight
    let ViewPort

    switch(true){
        // view port id xsmall
        case (innerWidth < 600):
            ViewPort = {
                ActualWidht: innerWidth,
                ActualHeight: innerHeight,
                IsXsmall: true,
                IsSmall: false,
                IsMedium: false,
                IsLarge: false,
                IsXlarge: false,
                Xsmall: true,
                Small: true,
                Medium: true,
                Large: true,
                Xlarge: true,
            }
            store.commit('SetViewPort', ViewPort)
            break

        // view port id small
        case (innerWidth <= 960):
            ViewPort = {
                ActualWidht: innerWidth,
                ActualHeight: innerHeight,
                IsXsmall: false,
                IsSmall: true,
                IsMedium: false,
                IsLarge: false,
                IsXlarge: false,
                Xsmall: false,
                Small: true,
                Medium: true,
                Large: true,
                Xlarge: true,
            }
            store.commit('SetViewPort', ViewPort)
            break

        // view port id medium
        case (innerWidth <= 1280):
            ViewPort = {
                ActualWidht: innerWidth,
                ActualHeight: innerHeight,
                IsXsmall: false,
                IsSmall: false,
                IsMedium: true,
                IsLarge: false,
                IsXlarge: false,
                Xsmall: false,
                Small: false,
                Medium: true,
                Large: true,
                Xlarge: true,
            }
            store.commit('SetViewPort', ViewPort)
            break

        // view port id large
        case (innerWidth <= 1920):
            ViewPort = {
                ActualWidht: innerWidth,
                ActualHeight: innerHeight,
                IsXsmall: false,
                IsSmall: false,
                IsMedium: false,
                IsLarge: true,
                IsXlarge: false,
                Xsmall: false,
                Small: false,
                Medium: false,
                Large: true,
                Xlarge: true,
            }
            store.commit('SetViewPort', ViewPort)
            break

        // view port id xlarge
        case (innerWidth > 1920):
            ViewPort = {
                ActualWidht: innerWidth,
                ActualHeight: innerHeight,
                IsXsmall: false,
                IsSmall: false,
                IsMedium: false,
                IsLarge: false,
                IsXlarge: true,
                Xsmall: false,
                Small: false,
                Medium: false,
                Large: false,
                Xlarge: true,
            }
            store.commit('SetViewPort', ViewPort)
            break
    }
}

export default {
    name: 'Flexible',
    data: () => ({
        menuVisible: false,
        params: "",
        winWidth: window.innerWidth,
        hassMessages: false,
        loginData: {
            User: '',
            Pass: '',
        }
    }),
    methods: {
        login: function() {
            this.$store.dispatch('Login', {'User': this.loginData.User, 'Pass': this.loginData.Pass})
        }
    },
    mounted() {
        this.params = this.$route.params;

        SetViewPort(this.$store)

        window.addEventListener('resize', () => {
            SetViewPort(this.$store)
            this.winWidth = window.innerWidth
        });

        this.$store.commit('SetAuth');

        setInterval(function() {
            this.$store.commit('SetAuth');
        }.bind(this), 30000)
    },
    updated() {
        this.params = this.$route.params
    },
    computed: {
        isPortal: function() {
            if (this.params.view) {
                if (this.params.view === 'portal') {
                    return true;
                } else return false;
            } else return false;
        },
        isManagement: function() {
            if (this.params.view) {
                if (this.params.view === 'management') {
                    return true;
                } else return false;
            } else return false;
        },
        breakPoint: function() {
            if (this.winWidth < 600) return 'xmsall'
            else if (this.winWidth <= 960) return 'small'
            else if (this.winWidth <= 1280) return 'medium'
            else if (this.winWidth <= 1920) return 'xlarge'
            else return 'xlarge'
        },
        messageClass () {
            return {
                'md-invalid': this.hassMessages
            }
        }
    },
};
</script>
