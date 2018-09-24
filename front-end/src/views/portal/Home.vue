<template>
<div class="sgh-portada">
  <section class="sgh-section" id="portada">
    <div>
      descanso y diversión en familia
    </div>
  </section>
  <section class="sgh-section" id="slider">
    <carousel :perPage="1" :autoplay="true" :autoplayTimeout="5000">
      <slide>
        <img src="/img/portal/promos/0.png" alt="">
      </slide>
      <slide>
        <img src="/img/portal/promos/1.png" alt="">
      </slide>
      <slide>
        <img src="/img/portal/promos/2.png" alt="">
      </slide>
    </carousel>
  </section>
  <section class="sgh-section" id="information">
    <section id="resort">
      <div>
        <h1>RESORT</h1>
        <span>
          Amplias áreas parquizadas sobre el mar, 
          piscina abierta con parque acuático, 
          piscina climatizada y cerrada a 35ºC, 
          estacionamiento vigilado, 
          sala de juegos para adultos y niños, 
          gimnasio, 
          canchas deportivas con vista al mar, 
          recreación para todas las edades, 
          salas de reuniones, 
          WiFI Free</span>
        <md-button>más información</md-button>
      </div>
    </section>
    <section id="chalets">
      <div>
        <h1>NUESTROS CHALETS</h1>
        <span>Ofrecemos 20 chalet totalmente equipados con capacidad hasta 4 personas y 8 chalet con capacidad hasta 6 personas.</span>
        <md-button>más información</md-button>
      </div>
    </section>
    <section id="compromiso">
      <div>
        <h1>COMPROMISO</h1>
        <span>
          El Descubrimiento Resort Club, siempre atento a la preservación del medio ambiente, 
          además del sistema de tratamiento ecológico de las aguas residuales, 
          instalado ya hace mucho tiempo (Humedales), a partir del presente año, 
          ha implementado también un moderno sistema de energías renovables 
          (Iluminación fotovoltaica y Energía térmica), 
          aplicados respectivamente a la iluminación de los espacios comunes y al calentamiento del agua, 
          tanto dentro de los chalets, como en las instalaciones de uso público 
          (Restaurante, vestuarios, baños, etc.) 
          con el fin de continuar con nuestra política de ser amigables con el medio ambiente.
          </span>
        <md-button>más información</md-button>
      </div>
    </section>
  </section>
</div>
</template>
<style lang="scss" scoped>
$section-height: calc(100vh - 192px);
  .sgh-portada {
    .sgh-section{
      height: $section-height;
    }
    #portada {
      height: calc(100vh - 192px);
      background-image: url('/img/portal/img_portada.png');
      background-position: center;
      background-size: cover;
      div{
        background: -webkit-linear-gradient(left, rgba(0, 0, 0, 0.5) 0%, rgba(3, 3, 3, 0.25) 100%);
        height: 100%;
        width: 100%;
        display: grid;
        grid-template-areas: "a";
        align-items: center;
        justify-content: center;
        color: white;
        font-family: 'Arima Madurai', cursive;
        font-size: 48px;
      }
    }
    #slider{
      height: $section-height;
      img{
        object-fit: cover;
        width: 100vw;
        height:$section-height;
      }
    }
    #information {
      display: grid;
      grid-template-rows: $section-height;
      grid-template-columns: repeat(3, 33.33vw);

      section {
        display: grid;
        grid-template-rows: 1fr;
        grid-template-columns: 1fr;
        div{
          transition: 0.5s;
          display: grid;
          grid-template-rows: 1fr 2fr 1fr;
          grid-template-columns: 1fr;
          align-items: center;
          justify-content: center;
          h1{
            grid-area: 1 / 1 / span 1 / span 1;
            transform: translatey(calc(50vh - 192px));
            transition: 0.5s;
            text-align: center;
            font-family: 'Montserrat', sans-serif;
            font-size: 24px !important;
            color: white;
          }
          span{
            grid-area: 2 / 1 / span 1 / span 1;
            transition: 0.5s;
            text-align: center;
            font-family: 'Montserrat', sans-serif;
            margin: 0 16px;
            color: white;
            transform: scale(0,0);
          }
          button{
            grid-area: 3 / 1 / span 1 / span 1;
            transition: 0.5s;
            max-width: 30vw;
            background-color: #0D47A1;
            color: white;
            margin: 8px auto;
          }
        }
      }
      section:hover{
        div{
          background-color: #2196F3AA;
          h1{
            transform: translatey(0vw);
          }
          span{
            transform: scale(1,1);
          }
        }
      }
      #resort{
        background-image: url('/img/portal/img-info-resort.jpg');
            background-position: center;
        background-size: cover;
      }
      #chalets{
        background-image: url('/img/portal/img-info-chalets.jpg');
            background-position: center;
        background-size: cover;
      }
      #compromiso{
        background-image: url('/img/portal/img-info-compromiso.jpg');
            background-position: center;
        background-size: cover;
      }
    }
  }

</style>
<style lang="scss">
      .VueCarousel-pagination{
        transform: translatey(-60px);      
      }

</style>
