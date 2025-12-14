package com.grigorijtomczuk.dbuser.data.net.model

import com.google.gson.annotations.SerializedName

data class Manufacturer(
    @SerializedName("Country") val country: String,
    @SerializedName("Mfr_CommonName") val commonName: String?,
    @SerializedName("Mfr_ID") val id: Int,
    @SerializedName("Mfr_Name") val name: String
)