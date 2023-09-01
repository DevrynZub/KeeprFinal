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
        <div class="row p-2">
          <div class="col-md-4 col-12 mb-3" v-for="keep in keeps" :key="keep.id">
            <KeepCard :keepProp="keep" />
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
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState';
import VaultCard from '../components/VaultCard.vue';
import { keepsService } from '../services/KeepsService.js';
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import KeepCard from '../components/KeepCard.vue';



export default {
  setup() {
    const editable = ref({});
    const route = useRoute();

    // FIXME add onMounted and get keeps ... think ab which id to pass to get the keeps for logged in user....you already have this written


    async function getKeeps(accountId) {
      try {
        await keepsService.getKeeps(accountId);

      }
      catch (error) {
        Pop.error('[Error]', error.message);
      }
    }



    onMounted(() => {
      route.params.profileId
      getKeeps()
    });


    return {
      editable,
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.myVaults),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { VaultCard, KeepCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
