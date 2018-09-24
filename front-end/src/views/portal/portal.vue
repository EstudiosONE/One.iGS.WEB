<template>
  <div id="Portal">
    <link href="https://fonts.googleapis.com/css?family=Arima+Madurai" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Dosis" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
    <head>
      <logo id="logo"/>
      <section id="menu">
        <md-button to="/portal/home">Home</md-button>
        <md-button to="/portal/home">Resort</md-button>
        <md-button to="/portal/home">Servicios</md-button>
        <md-button to="/portal/home">Eventos</md-button>
        <md-button to="/portal/home">Promociones</md-button>
        <md-button to="/portal/home">Contacto</md-button>
      </section>
    </head>
    <head>
      <section id="menu-min">
        <md-button to="/portal/home">Home</md-button>
        <md-button to="/portal/home">Resort</md-button>
        <md-button to="/portal/home">Servicios</md-button>
        <logo id="logo"/>
        <md-button to="/portal/home">Eventos</md-button>
        <md-button to="/portal/home">Promociones</md-button>
        <md-button to="/portal/home">Contacto</md-button>
      </section>
    </head>
    <md-content id="Content" class="md-scrollbar" v-on:scroll="scrollFunction">
      <router-view/>
      <footer>
        <div>
          <section id="ubicacion">
            <h2>Ubicación</h2>
            <span>Ruta Interbalnearia Km. 59.800 Canelones, Uruguay</span>
            <md-button>Ver mapa</md-button>
          </section>
          <section id="contactenos">
            <h2>Contactenos</h2>
            <span>
              <span>info@eldescubrimiento.com</span>
              <br/>
              <span>[+598] 4378 2141 / 2143</span>
            </span>
          </section>
          <section id="trabaja">
            <h2>Trabaja con nosotros</h2>
            <span>En El Descubrimiento Resort Club buscamos personas pro-activas que se involucren de forma comprometida. Envianos tu curriculum y se parte.</span>
            <md-button>Formulario</md-button>
          </section>
          <section id="newsletter">
            <h2>Newsletter</h2>
            <span>Envienos su e-mail y reciba todas las novedades y promociones especiales del Resort.</span>
            <md-button>Formulario</md-button>
          </section>
          <section id="redes">
            <logo-footer/>
          </section>
        </div>
      </footer>
    </md-content>
  </div>
</template>
<script>
import Logo from '@/components/portal/Logo.vue'
import LogoFooter from '@/components/portal/Logo-footer.vue'

let element = document.getElementById('Content')

export default {
  components: {
    Logo,
    LogoFooter
  },
  methods: {
    scrollFunction: function(){
      if(element.scrollTop > 0){

      }
    }
  
  },
  data: function() {
    return {
      newsletter: '',
    }
  }
}
</script>

<style lang="scss" scoped>
#Portal{
  width: 100vw;
  height: 100vh;
  overflow: hidden;
  head{
    z-index: 1000;
    position: fixed;
    height: 192px;
    width: 100vw;
    display: grid;
    grid-template-columns: 1fr;
    grid-template-rows: 128px 64px;
    background-color: white;
    align-items: center;
    justify-content: center;
    #logo{
      align-items: center;
      justify-content: center;
      max-width: 100vw;
    }
    #menu{
      width: fit-content;
      justify-content: center;
      align-items: center;
      margin: auto;
      a{
        width: 120px;
      }
    }
  }
  #Content{
    display: grid;
    height: calc(100vh - 192px);
    width: 100vw;
    grid-template-columns: 1fr;
    grid-template-rows: 1fr 434px;
    overflow-y: scroll;
    overflow-x: hidden;
    position: absolute;
    top: 192px;
    footer{
      grid-area: 2 / 1 / span 1 / span 1;
      background-image: url('/img/portal/footer.png');
      background-position: bottom;
      background-size: cover;
    }
  }
  footer{
      display: grid;
      grid-template-rows: 1fr;
      grid-template-columns: 1fr;
      justify-content: center;
      align-items: center;
    div{
      display: grid;
      grid-template-rows: 314px 120px;
      grid-template-columns: repeat(4, 1fr);
      max-width: 960px;
      margin: 0 auto;
    }
    section{
      display: grid;
      grid-template-rows: 74px 120px 120px;
      grid-template-columns: 1fr;
      font-family: 'Arima Madurai', cursive;
      padding: 16px;
      color: white;
      h2{
        font-weight: normal;
      }
      span{
        text-align: justify;
      }
      button{
        border: 1px solid white;
        color: white;
      }
    }
  }
}
</style>
