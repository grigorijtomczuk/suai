package com.grigorijtomczuk.apiuser.api

import com.google.gson.annotations.SerializedName

data class Manufacturer(
    @SerializedName("Mfr_ID") val id: Int,
    @SerializedName("Mfr_Name") val name: String,
    @SerializedName("Mfr_CommonName") val commonName: String?,
    @SerializedName("Country") val country: String
)

data class ManufacturerResponse(
    @SerializedName("Results") val results: List<Manufacturer>
)
