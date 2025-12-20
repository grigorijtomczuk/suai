package com.grigorijtomczuk.dbuser

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.fragment.app.Fragment
import org.json.JSONArray
import java.net.HttpURLConnection
import java.net.URL
import kotlin.concurrent.thread

class JsonFragment : Fragment() {

    private lateinit var tvJsonResult: TextView
    private lateinit var btnLoadJson: Button

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_json, container, false)
        tvJsonResult = view.findViewById(R.id.tvJsonResult)
        btnLoadJson = view.findViewById(R.id.btnLoadJson)

        btnLoadJson.setOnClickListener {
            loadJson()
        }

        return view
    }

    private fun loadJson() {
        tvJsonResult.text = "Загрузка..."
        thread {
            try {
                val url = URL("https://jsonplaceholder.typicode.com/users")
                val connection = url.openConnection() as HttpURLConnection
                connection.requestMethod = "GET"
                connection.connectTimeout = 5000
                connection.readTimeout = 5000

                if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                    val text = connection.inputStream.bufferedReader().readText()

                    // Парсим JSON
                    val jsonArray = JSONArray(text)
                    val stringBuilder = StringBuilder()

                    for (i in 0 until jsonArray.length()) {
                        val userObject = jsonArray.getJSONObject(i)
                        val name = userObject.getString("name")
                        val email = userObject.getString("email")
                        val company = userObject.getJSONObject("company").getString("name")

                        stringBuilder.append("Имя: $name\n")
                        stringBuilder.append("Email: $email\n")
                        stringBuilder.append("Компания: $company\n")
                        stringBuilder.append("--------------------------------\n")
                    }

                    requireActivity().runOnUiThread {
                        tvJsonResult.text = stringBuilder.toString()
                    }
                } else {
                    requireActivity().runOnUiThread {
                        tvJsonResult.text = "Ошибка: ${connection.responseCode}"
                    }
                }
            } catch (e: Exception) {
                e.printStackTrace()
                requireActivity().runOnUiThread {
                    tvJsonResult.text = "Ошибка: ${e.message}"
                }
            }
        }
    }
}
