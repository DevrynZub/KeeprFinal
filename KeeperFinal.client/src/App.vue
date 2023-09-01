<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <XLModal id="keepDetails">
    <template #body>
      <ActiveKeep />
    </template>
  </XLModal>

  <ModalComponent id="editAccount">
    <template #modalHeader>
      Update Account
    </template>
    <template #modalBody>
      <UpdateAccount />
    </template>
  </ModalComponent>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import UpdateAccount from './components/UpdateAccount.vue'
import ActiveKeep from './components/ActiveKeep.vue'


export default {
  setup() {

    return {
      appState: computed(() => AppState),
    }
  },
  components: { Navbar, UpdateAccount, ActiveKeep }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
