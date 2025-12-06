package com.grigorijtomczuk.mygallery

import android.net.Uri
import android.os.Bundle
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.floatingactionbutton.FloatingActionButton

class MainActivity : AppCompatActivity() {

    private lateinit var recyclerView: RecyclerView
    private lateinit var fab: FloatingActionButton
    private val imageUris = mutableListOf<Uri>()
    private lateinit var imageAdapter: ImageAdapter

    // ActivityResultLauncher для получения изображения из галереи
    private val selectImageLauncher =
        registerForActivityResult(ActivityResultContracts.GetContent()) { uri: Uri? ->
            // Изображение выбрано
            uri?.let {
                imageUris.add(it)
                imageAdapter.notifyDataSetChanged()
            }
        }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        // Инициализируем RecyclerView и FloatingActionButton из макета
        recyclerView = findViewById(R.id.recyclerView)
        fab = findViewById(R.id.fab)

        // иницализируем адаптер
        imageAdapter = ImageAdapter(imageUris)
        recyclerView.layoutManager =
            GridLayoutManager(this, 3) // GridLayoutManager для отображения в 3 колонки
        recyclerView.adapter = imageAdapter

        fab.setOnClickListener {
            // Запускаем галерею для выбора изображения
            selectImageLauncher.launch("image/*")
        }
    }
}