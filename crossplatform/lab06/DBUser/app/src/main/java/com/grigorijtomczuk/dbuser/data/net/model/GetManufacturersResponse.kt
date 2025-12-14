package com.grigorijtomczuk.dbuser.data.net.model

import com.google.gson.annotations.SerializedName

data class GetManufacturersResponse(
    @SerializedName("Results") val results: List<Manufacturer>
)