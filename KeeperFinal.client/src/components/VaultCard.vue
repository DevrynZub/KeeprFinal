<template>
  <div class="vault-image" :style="{ backgroundImage: 'url(' + vaultProp.img + ')' }">
    <h3 class="vault-name elevation">{{ vaultProp.name }}</h3>
  </div>
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


<style lang="scss" scoped></style>