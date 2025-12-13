package com.grigorijtomczuk.apiuser.api

import com.google.gson.annotations.SerializedName

data class Motorcycle(
    @SerializedName("make") val make: String,
    @SerializedName("model") val model: String,
    @SerializedName("year") val year: Int,
    @SerializedName("type") val type: String,
    @SerializedName("power") val power: String
)
