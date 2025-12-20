package com.grigorijtomczuk.mapuser

import android.app.AlertDialog
import android.os.Bundle
import android.widget.EditText
import android.widget.LinearLayout
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.yandex.mapkit.Animation
import com.yandex.mapkit.MapKitFactory
import com.yandex.mapkit.geometry.Point
import com.yandex.mapkit.map.CameraPosition
import com.yandex.mapkit.map.InputListener
import com.yandex.mapkit.map.Map
import com.yandex.mapkit.map.MapObjectTapListener
import com.yandex.mapkit.map.PlacemarkMapObject
import com.yandex.mapkit.map.TextStyle
import com.yandex.mapkit.mapview.MapView
import com.yandex.runtime.image.ImageProvider

data class MarkerData(var title: String, val snippet: String)

class MapActivity : AppCompatActivity() {

    private lateinit var mapView: MapView
    private val markers = mutableListOf<PlacemarkMapObject>()

    private val inputListener = object : InputListener {
        override fun onMapTap(map: Map, point: Point) {
            showAddMarkerDialog(point)
        }

        override fun onMapLongTap(map: Map, point: Point) {
            val touchedMarker = findMarkerAt(point)
            if (touchedMarker != null) {
                val userData = touchedMarker.userData
                if (userData is MarkerData) {
                    showEditMarkerDialog(touchedMarker, userData)
                }
            }
        }
    }

    private val placemarkTapListener = MapObjectTapListener { mapObject, point ->
        val userData = mapObject.userData
        if (userData is MarkerData) {
            Toast.makeText(
                this@MapActivity,
                "${userData.title}\n${userData.snippet}",
                Toast.LENGTH_SHORT
            ).show()
        }
        true
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_map)

        mapView = findViewById(R.id.mapview)

        // Смещаем камеру на Москву
        mapView.map.move(
            CameraPosition(Point(55.7558, 37.6173), 10.0f, 0.0f, 0.0f),
            Animation(Animation.Type.SMOOTH, 1f),
            null
        )

        // Тестовая метка
        val redSquarePoint = Point(55.7539, 37.6208)
        addMarker(redSquarePoint, "Красная площадь")

        mapView.map.addInputListener(inputListener)
    }

    private fun addMarker(point: Point, title: String) {
        val placemark = mapView.map.mapObjects.addPlacemark(point)
        val snippet = "${String.format("%.4f", point.latitude)}; ${
            String.format(
                "%.4f",
                point.longitude
            )
        }"

        placemark.setIcon(ImageProvider.fromResource(this, android.R.drawable.presence_online))
        placemark.userData = MarkerData(title, snippet)
        placemark.setText(title, TextStyle().apply { placement = TextStyle.Placement.BOTTOM })
        placemark.addTapListener(placemarkTapListener)

        markers.add(placemark)
    }

    private fun findMarkerAt(point: Point): PlacemarkMapObject? {
        // Конвертация mapPoint в screenPoint
        val mapWindow = mapView.mapWindow ?: return null
        val touchScreenPoint = mapWindow.worldToScreen(point) ?: return null

        // Радиус для поиска (50dp)
        val threshold = 50 * resources.displayMetrics.density

        var closestMarker: PlacemarkMapObject? = null
        var minDistance = Double.MAX_VALUE

        for (marker in markers) {
            val markerPoint = marker.geometry
            val markerScreenPoint = mapWindow.worldToScreen(markerPoint) ?: continue

            val dx = touchScreenPoint.x - markerScreenPoint.x
            val dy = touchScreenPoint.y - markerScreenPoint.y
            val distance = Math.hypot(dx.toDouble(), dy.toDouble())

            if (distance <= threshold && distance < minDistance) {
                minDistance = distance
                closestMarker = marker
            }
        }

        return closestMarker
    }

    private fun showAddMarkerDialog(point: Point) {
        val builder = AlertDialog.Builder(this)
        builder.setTitle("Новая метка")

        val input = EditText(this)
        input.hint = "Введите название"

        val container = LinearLayout(this)
        container.orientation = LinearLayout.VERTICAL
        val params = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.MATCH_PARENT,
            LinearLayout.LayoutParams.WRAP_CONTENT
        )
        val margin = (20 * resources.displayMetrics.density).toInt()
        params.setMargins(margin, margin / 2, margin, 0)
        input.layoutParams = params
        container.addView(input)

        builder.setView(container)

        builder.setPositiveButton("Добавить") { _, _ ->
            val title = input.text.toString().ifBlank { "Новая метка" }
            addMarker(point, title)
        }
        builder.setNegativeButton("Отмена") { dialog, _ -> dialog.cancel() }

        builder.show()
    }

    private fun showEditMarkerDialog(mapObject: PlacemarkMapObject, data: MarkerData) {
        val builder = AlertDialog.Builder(this)
        builder.setTitle("Редактирование метки")
        builder.setMessage(data.snippet)

        val input = EditText(this)
        input.setText(data.title)

        val container = LinearLayout(this)
        container.orientation = LinearLayout.VERTICAL
        val params = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.MATCH_PARENT,
            LinearLayout.LayoutParams.WRAP_CONTENT
        )
        val margin = (20 * resources.displayMetrics.density).toInt()
        params.setMargins(margin, margin / 2, margin, 0)
        input.layoutParams = params
        container.addView(input)

        builder.setView(container)

        builder.setPositiveButton("Сохранить") { _, _ ->
            val newTitle = input.text.toString()
            if (newTitle.isNotBlank()) {
                data.title = newTitle
                mapObject.setText(newTitle)
                Toast.makeText(this, "Метка обновлена", Toast.LENGTH_SHORT).show()
            }
        }

        builder.setNegativeButton("Удалить") { _, _ ->
            mapView.map.mapObjects.remove(mapObject)
            markers.remove(mapObject)
            Toast.makeText(this, "Метка удалена", Toast.LENGTH_SHORT).show()
        }

        builder.setNeutralButton("Отмена") { dialog, _ -> dialog.cancel() }

        builder.show()
    }

    override fun onStop() {
        mapView.onStop()
        MapKitFactory.getInstance().onStop()
        super.onStop()
    }

    override fun onStart() {
        super.onStart()
        MapKitFactory.getInstance().onStart()
        mapView.onStart()
    }
}
