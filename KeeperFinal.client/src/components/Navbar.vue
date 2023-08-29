<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <i>Home</i>
      </div>
    </router-link>

    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div>
      <button class="createForm btn btn-light" data-bs-target="#createKeep" data-bs-toggle="modal">
        <i> Create Keep</i>
      </button>
      <button class="createForm btn btn-light ms-2" data-bs-target="#createVault" data-bs-toggle="modal">
        <i> Create Vault</i>
      </button>
    </div>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>



    <ModalComponent id="createKeep">
      <template #modalHeader>
        Create Keep
      </template>
      <template #modalBody>
        <CreateKeep />
      </template>
    </ModalComponent>

    <ModalComponent id="createVault">
      <template #modalHeader>
        Create Vault
      </template>
      <template #modalBody>
        <CreateVault />
      </template>
    </ModalComponent>
  </nav>
</template>

<script>
import CreateKeep from './CreateKeep.vue';
import CreateVault from './CreateVault.vue';
import Login from './Login.vue';
export default {
  setup() {

    return {}
  },
  components: { Login, CreateKeep, CreateVault }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
