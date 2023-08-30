<template>
  <router-link :to="{ name: 'ActiveVaultPage', params: { vaultId: vaultProp.id } }" class="vault-card">
    <div class="vault-image" :style="{ backgroundImage: 'url(' + vaultProp.img + ')' }">
      <h3 class="vault-name elevation">{{ vaultProp.name }}</h3>
    </div>
  </router-link>
</template>






<script>
import { Vault } from '../models/Vault.js';

export default {

  props: {
    vaultProp: { type: Vault, require: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.vault-card {
  background-color: #ffffff;
  border: 1px solid #ddd;
  border-radius: 8px;
  box-shadow: 0px 3px 6px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.vault-image {
  height: 120px;
  background-size: cover;
  background-position: center;
  position: relative;
}

.vault-name {
  margin: 10px 0;
  font-size: 16px;
}

.vault-card:hover {
  transform: translateY(-3px);
  box-shadow: 0px 6px 12px rgba(0, 0, 0, 0.1);
}
</style>