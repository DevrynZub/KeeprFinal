<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">

      </div>
    </div>

  </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { vaultService } from '../services/VaultService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

export default {
  setup() {

    async function getVaults() {
      try {
        await vaultService.getVaults();
      } catch (error) {
        Pop.error(error.message)
      }
    }

    onMounted(() => {
      getVaults();
    })

    return {
      vault: computed(() => AppState.vaults)
    }
  }
}
</script>


<style lang="scss" scoped></style>