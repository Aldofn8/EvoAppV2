<template>
  <div>
    <div class="container mt-5">
      <h1 class="display-4 mb-4">Información del Contrato</h1>
      <form  class="mb-4">
        <div class="mb-3">
          <label for="id" class="form-label">Número del Contrato:</label>
          <input type="text" class="form-control" v-model="id" required>
        </div>
        
      </form>
      <button class="btn btn-primary" v-on:click="getMyViewById(id)">Buscar</button>

      <div v-if="MyView" class="border p-3">
        <h2 class="h4">Detalles del Contrato:</h2>
        <div class="input-group">
          <span class="input-group-text" id="basic-addon1">Código de curso:</span>
          <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" readonly v-model="MyView.courseCode">
        </div>
        <div class="input-group">
          <span class="input-group-text" id="basic-addon1">Fecha de alta:</span>
          <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" readonly v-model="MyView.fechaAlta">
        </div>
        <div class="input-group">
          <span class="input-group-text" id="basic-addon1">Colegio:</span>
          <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" readonly v-model="MyView.colegioNombre">
        </div>
        <div class="input-group">
          <span class="input-group-text" id="basic-addon1">Nivel:</span>
          <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" readonly v-model="MyView.colegioNivel">
        </div>
        <div class="input-group">
          <span class="input-group-text" id="basic-addon1">Curso:</span>
          <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" readonly v-model="MyView.colegioCurso">
        </div>
        <div class="input-group">
          <span class="input-group-text" id="basic-addon1">Localidad:</span>
          <input type="text" class="form-control" aria-label="Username" aria-describedby="basic-addon1" readonly v-model="MyView.colegioLocalidad">
        </div>

        <h2 class="h4">Pedido:</h2>
        <div class="table">
          <thead>
            <tr>
              <th>Cantidad</th>
              <th>Artículo</th>
              <th>Precio unitario</th>
              <th>Total</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in articleList" :key="index">
              <td>{{ MyView.cantidadEgresados }}</td>
              <td>{{ item.articleNombre }}</td>
              <td>{{ item.articlePrecio }}</td>
              <td>{{ MyView.cantidadEgresados * item.articlePrecio  }}</td>
            </tr>
          </tbody>
        </div>

        <p><strong>Total:</strong> {{ calcularTotal() }}</p>
        <p><strong>Fecha de entrega:</strong> {{ MyView.fechaEntrega }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.css';

export default {
  data() {
    return {
      id: "",
      MyView: null,
      articleList: null
    };
  },
  methods: {
    async getMyViewById(id) {
      event.preventDefault();
      let apiUrl = 'https://localhost:7010/api';
      axios.get(`${apiUrl}/MyView/${id}`)
        .then(response => {
          this.MyView = response.data;
          console.log("HOLAS", this.MyView);
          this.getMyArticleListById(this.MyView.contractId)
        })
        .catch(error => {
          console.error("Error al buscar details:", error);
        });
    },
    async getMyArticleListById(id) {
      event.preventDefault();
      let apiUrl = 'https://localhost:7010/api';
      axios.get(`${apiUrl}/MyArticleList/${id}`)
        .then(response => {
          this.articleList = response.data;
          console.log(this.articleList);
        })
        .catch(error => {
          console.error("Error al buscar details:", error);
        });
    },
    calcularTotal() {
      // Aquí puedes implementar la lógica para calcular el total del pedido.
      if (!this.MyView || !this.articleList) {
      return 0; // Devolver 0 si MyView o articleList no están definidos.
      }

      let total = 0;

      // Iterar sobre los elementos en articleList
      for (let i = 0; i < this.articleList.length; i++) {
        const item = this.articleList[i];
        const subtotal = this.MyView.cantidadEgresados * item.articlePrecio;
        total += subtotal;
      }

      return total;
    }
  },
};
</script>

<style scoped>
/* Estilos CSS para tu componente Vue */
</style>

