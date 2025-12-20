package com.grigorijtomczuk.authuser

import android.app.AlertDialog
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.firestore.FirebaseFirestore
import com.grigorijtomczuk.authuser.databinding.FragmentProfileBinding

class ProfileFragment : Fragment() {

    private var _binding: FragmentProfileBinding? = null
    private val binding get() = _binding!!
    private lateinit var auth: FirebaseAuth
    private lateinit var db: FirebaseFirestore

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentProfileBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        auth = FirebaseAuth.getInstance()
        db = FirebaseFirestore.getInstance()

        loadUserData()

        binding.btnUpdate.setOnClickListener {
            updateUserData()
        }

        binding.btnLogout.setOnClickListener {
            auth.signOut()
            findNavController().navigate(R.id.action_profileFragment_to_loginFragment)
        }

        binding.btnDeleteAccount.setOnClickListener {
            showDeleteAccountConfirmation()
        }
    }

    private fun loadUserData() {
        val user = auth.currentUser
        if (user != null) {
            binding.etEmail.setText(user.email)
            db.collection("users").document(user.uid).get()
                .addOnSuccessListener { document ->
                    if (document != null) {
                        binding.etMotorcycleModel.setText(document.getString("motorcycleModel"))
                    }
                }
                .addOnFailureListener {
                    Toast.makeText(
                        context,
                        "Ошибка загрузки данных пользователя",
                        Toast.LENGTH_SHORT
                    ).show()
                }
        }
    }

    private fun updateUserData() {
        val user = auth.currentUser
        binding.etEmail.text.toString()
        val newPassword = binding.etPassword.text.toString()
        val newMotorcycleModel = binding.etMotorcycleModel.text.toString()

        if (user != null) {
            // Обноволение Email
//            if (newEmail.isNotEmpty() && newEmail != user.email) {
//                user.updateEmail(newEmail).addOnCompleteListener { task ->
//                    if (task.isSuccessful) {
//                        Toast.makeText(context, "Email обновлен", Toast.LENGTH_SHORT).show()
//                    } else {
//                        Log.d("TAG", task.exception?.message.toString())
//                        Toast.makeText(
//                            context,
//                            "Ошибка обновления Email: ${task.exception?.message}",
//                            Toast.LENGTH_SHORT
//                        ).show()
//                    }
//                }
//            }

            // Обноволение пароля
            if (newPassword.isNotEmpty()) {
                user.updatePassword(newPassword).addOnCompleteListener { task ->
                    if (task.isSuccessful) {
                        Toast.makeText(context, "Пароль обновлен", Toast.LENGTH_SHORT).show()
                    } else {
                        Toast.makeText(
                            context,
                            "Ошибка обновления пароля: ${task.exception?.message}",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }
            }

            // Обноволение модели мотоцикла
            val userData = hashMapOf<String, Any>(
                "motorcycleModel" to newMotorcycleModel
            )
            db.collection("users").document(user.uid).update(userData)
                .addOnSuccessListener {
                    Toast.makeText(context, "Данные обновлены", Toast.LENGTH_SHORT).show()
                }
                .addOnFailureListener {
                    Toast.makeText(context, "Ошибка обновления данных", Toast.LENGTH_SHORT).show()
                }
        }
    }

    private fun showDeleteAccountConfirmation() {
        AlertDialog.Builder(context)
            .setTitle("Удалить аккаунт")
            .setMessage("Вы уверены, что хотите удалить свой аккаунт?")
            .setPositiveButton("Да, удалить") { _, _ ->
                deleteAccount()
            }
            .setNegativeButton("Нет", null)
            .show()
    }

    private fun deleteAccount() {
        val user = auth.currentUser
        user?.let { u ->
            db.collection("users").document(u.uid).delete()
                .addOnSuccessListener {
                    u.delete().addOnCompleteListener { task ->
                        if (task.isSuccessful) {
                            Toast.makeText(context, "Аккаунт удален", Toast.LENGTH_SHORT).show()
                            findNavController().navigate(R.id.action_profileFragment_to_loginFragment)
                        } else {
                            Toast.makeText(
                                context,
                                "Ошибка удаления аккаунта: ${task.exception?.message}",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    }
                }
                .addOnFailureListener {
                    Toast.makeText(
                        context,
                        "Ошибка удаления данных пользователя",
                        Toast.LENGTH_SHORT
                    ).show()
                }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}
