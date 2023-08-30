<template>
  <div class="container-fluid account-page">
    <div class="text-center">
      <button v-if="account.id" class="btn btn-outline-primary" type="button" data-bs-toggle="modal"
        data-bs-target="#editAccount">
        Update Account
      </button>
    </div>
    <div class="row justify-content-around">
      <div class="col-12 col-md-3 mb-5">
        <div>
          <img :src="account.coverImg" alt="profile">
        </div>
        <div class="m-2 text-center">
          <img :src="account.picture" alt="profile">
          <div>
            <p class="card-text">{{ account.name }}</p>
          </div>
        </div>
        <div class="row">
          <h1>Vaults</h1>
          <div class="col-md-4 col-12 mb-3" v-for="vault in vaults" :key="vault.id">
            <VaultCard :vaultProp="vault" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, ref, watchEffect } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop.js';
import { vaultService } from '../services/VaultService.js';
import VaultCard from '../components/VaultCard.vue';



export default {
  setup() {
    const user = ref({});
    const editable = ref({});

    async function getVaultsByAccount() {
      try {
        let userId = user.value.id;
        await vaultService.getVaultsByAccount(userId);
      }
      catch (error) {
        Pop.error(error);
      }
    }


    watchEffect(() => {
      getVaultsByAccount();
    });
    return {
      editable,
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
    };
  },
  components: { VaultCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
